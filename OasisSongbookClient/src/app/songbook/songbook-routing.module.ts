import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SongbookComponent } from './songbook.component';

const routes: Routes = [
  {
    path: '',
    component: SongbookComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class SongbookRoutingModule { }
