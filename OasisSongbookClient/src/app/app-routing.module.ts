import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
    data: { preload: true }
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule),
    data: { preload: false }
  },
  {
    path: 'song',
    loadChildren: () => import('./song/song.module').then(m => m.SongModule),
    data: { preload: false }
  },
  {
    path: 'songbook',
    loadChildren: () => import('./songbook/songbook.module').then(m => m.SongbookModule),
    data: { preload: false }
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  // {
  //   path: 'u',
  //   loadChildren: () => import('./user/user.module').then(m => m.UserModule),
  //   data: { preload: false }
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
