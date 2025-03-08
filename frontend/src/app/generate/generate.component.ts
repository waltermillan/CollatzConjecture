import { Component, OnInit } from '@angular/core';
import { CollatzService } from '../services/collatz.service';

@Component({
  selector: 'app-generate',
  templateUrl: './generate.component.html',
  styleUrl: './generate.component.css'
})
export class GenerateComponent implements OnInit {

  numbers: Array<number> = [];

  constructor(private collatzService: CollatzService
  ) { }

  ngOnInit(){

  }

  generate(value:string) {
    let nValue: number = parseInt(value, 10);

    this.collatzService.generate(nValue).subscribe({
      next: (data:any) => {
        console.log(data);
        this.numbers = data;
      },
      error: (error) => {
        console.error('Error al obtener resultado', error);
      }
    })
  }

  delete(): void{
    this.numbers = [];
  }

}
