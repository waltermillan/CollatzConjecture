import { Component, OnInit, AfterViewChecked, ViewChild, ElementRef  } from '@angular/core';
import { CollatzService } from '../services/collatz.service';
import { CollatzConjecture } from '../models/collatz-conjecture';
import { colorSets } from '@swimlane/ngx-charts';

@Component({
  selector: 'app-generate',
  templateUrl: './generate.component.html',
  styleUrls: ['./generate.component.css']
})
export class GenerateComponent implements OnInit, AfterViewChecked {

  @ViewChild('valueTextbox') valueTextbox: ElementRef | undefined;

  collatzConjecture: CollatzConjecture = new CollatzConjecture();
  value: string = '';
  isValid: boolean = true;
  numbers: Array<number> = [];
  chartData: any[] = [];
  enabledShowPopup: boolean = false;
  

  colorScheme = colorSets.find(s => s.name === 'cool') || colorSets[0]; 

  view: [number, number] = [window.innerWidth, 400];

  constructor(private collatzService: CollatzService)
  {}

  ngOnInit(): void {
  }

  showPopup(visible: boolean): void {
    this.enabledShowPopup = visible;
  }

  ngAfterViewChecked() {
    if (this.valueTextbox) {
      this.valueTextbox.nativeElement.focus();
    }
  }

  setIsValidOperation(isValid: boolean) {
    this.isValid = isValid;
  }

  setFocus(): void {
    if (this.valueTextbox) {
      this.valueTextbox.nativeElement.focus();
    }
  }

  closePopup(): void {
    this.isValid = true;
    this.delete();
  }

  generate(value: string) {
    let nValue: number = parseInt(value, 10);

    if (nValue < 0 || nValue > 2100000000) {
      this.setIsValidOperation(false);
      this.delete();
      this.setFocus();
      return;
    }

    this.collatzService.generate(nValue).subscribe({
      next: (data: any) => {

        this.numbers = data;
        this.add(data.length);

        // Update dato graphic
        this.chartData = [
          {
            "name": "Secuencia de Collatz",
            "series": this.numbers.map((value, index) => ({ name: index.toString(), value: value }))
          }
        ];

        this.setFocus();
      },
      error: (error) => {
        console.error('Error getting result.', error);
      }
    });
  }

  delete(): void {
    this.numbers = [];
    this.value = '';
    this.setFocus();
    this.clearChart();
    this.enabledShowPopup = false;
  }

  add(numSteps:number) {
    this.collatzConjecture = {
      _id: '',
      Sequence: this.numbers,
      StartingNumber: this.value,
      NumSteps: numSteps,
      Timestamp: new Date(),
    };

    this.collatzService.add(this.collatzConjecture).subscribe({
      next: () => {
        console.log('Sequence added to the database.');
      },
      error: (error) => {
        console.log('Error when adding the sequence.');
      }
    });
  }

  clearChart() {
    this.chartData = [];  // Clean data graphic
    this.numbers = [];    // Clean secuence data
    this.value = '';      // Clean data enter
    this.collatzConjecture.NumSteps = 0;  // Restart NumSteps
  }

}
