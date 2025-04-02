import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricalInformationComponent } from './historical-information.component';

describe('HistoricalInformationComponent', () => {
  let component: HistoricalInformationComponent;
  let fixture: ComponentFixture<HistoricalInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HistoricalInformationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HistoricalInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
