using API.Extensions;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace API.Controllers;

public class CollatzConjectureController : BaseApiController
{
    private readonly ICollatzConjectureRepository _collatzConjecturetRepository;

    public CollatzConjectureController(ICollatzConjectureRepository collatzConjecturetRepository)
    {
        _collatzConjecturetRepository = collatzConjecturetRepository;
    }

    [HttpGet("service")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task <ActionResult<List<long>>> Get(long value)
    {
        List<long> list = new List<long>();
        list.Add(value);
        try
        {
            while (value != 1)
            {
                if ((value % 2) == 0)
                    value = Functions.FunctionDivideByTwo(value);
                else
                    value = Functions.FunctionThreeXplusOne(value);

                list.Add(value);
            }

            return Task.FromResult<ActionResult<List<long>>>(list);
        }
        catch (Exception ex)
        {
            return Task.FromResult<ActionResult<List<long>>>(StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message }));
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CollatzConjecture>>> Get()
    {
        var conjetures = await _collatzConjecturetRepository.GetAllAsync();

        if (conjetures is null || !conjetures.Any())
            return NotFound();

        var response = conjetures.Select(collatzConjecture => new
        {
            id = collatzConjecture.Id.ToString(),  // ObjectId to string Convertion
            collatzConjecture.NumSteps,
            collatzConjecture.StartingNumber,
            collatzConjecture.Sequence,
            collatzConjecture.Timestamp
        }).ToList();

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CollatzConjecture>> Get([FromBody] ObjectId id)
    {
        var collatzConjecture = await _collatzConjecturetRepository.GetByIdAsync(id);

        if (collatzConjecture is null)
            return NotFound();

        var response = new
        {
            id = collatzConjecture.Id.ToString(),
            collatzConjecture.StartingNumber,
            collatzConjecture.Sequence,
            collatzConjecture.NumSteps,
            collatzConjecture.Timestamp
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CollatzConjecture>> Post([FromBody] CollatzConjecture collatzConjecture)
    {
        if (collatzConjecture is null)
            return BadRequest();

        await _collatzConjecturetRepository.CreateAsync(collatzConjecture);
        return CreatedAtAction(nameof(Get), new { id = collatzConjecture.Id }, collatzConjecture);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CollatzConjecture>> Put(string id, [FromBody] CollatzConjecture collatzConjecture)
    {
        if (!ObjectId.TryParse(id, out var objectId))
            return BadRequest("Invalid ObjectId format.");

        collatzConjecture.Id = objectId;

        if (collatzConjecture is null)
            return NotFound();

        await _collatzConjecturetRepository.UpdateAsync(collatzConjecture);
        return Ok(collatzConjecture);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(ObjectId id)
    {
        var collatzConjecture = await _collatzConjecturetRepository.GetByIdAsync(id);

        if (collatzConjecture is null)
            return NotFound();

        await _collatzConjecturetRepository.DeleteAsync(id);
        return NoContent();
    }
}
