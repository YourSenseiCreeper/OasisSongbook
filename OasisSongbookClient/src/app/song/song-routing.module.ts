import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SongAllListComponent } from './all-list/song-all-list.component';
import { SongComponent } from './song.component';

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: '',
      component: SongAllListComponent,
      pathMatch: 'full'
    },
  ])],
  exports: [RouterModule]
})
export class SongRoutingModule { }
