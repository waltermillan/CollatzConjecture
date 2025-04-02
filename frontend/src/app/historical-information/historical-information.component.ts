import { Component, OnInit } from '@angular/core';

import { CollatzConjecture } from '../models/collatz-conjecture';
import { CollatzService } from '../services/collatz.service';

@Component({
  selector: 'app-historical-information',
  templateUrl: './historical-information.component.html',
  styleUrl: './historical-information.component.css'
})
export class HistoricalInformationComponent implements OnInit {

  conjetures:CollatzConjecture[] = [];

  constructor(private collatzService:CollatzService){ 
  }

  ngOnInit(): void {
    this.getAllHistorical();
  }
  
  getAllHistorical() {
    this.collatzService.getAll().subscribe({
      next: (data) => {
 
        this.conjetures = data.sort((a, b) => 
              new Date(b.timestamp).getTime() - new Date(a.timestamp).getTime()).slice(0, 15);
       },
      error: (error) => {
        console.error('Error getting conjetures.', error);
      }
    });
  }
}
