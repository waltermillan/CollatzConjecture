import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InfoComponent } from './info/info.component';
import { GenerateComponent } from './generate/generate.component';
import { HistoricalInformationComponent } from './historical-information/historical-information.component';

const routes: Routes = [
  { path: 'info', component: InfoComponent },
  { path: 'generate', component: GenerateComponent},
  { path: 'historical', component: HistoricalInformationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
