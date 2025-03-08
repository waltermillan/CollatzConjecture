import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InfoComponent } from './info/info.component';
import { GenerateComponent } from './generate/generate.component';

const routes: Routes = [
  { path: 'info', component: InfoComponent },
  { path: 'generate', component: GenerateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
