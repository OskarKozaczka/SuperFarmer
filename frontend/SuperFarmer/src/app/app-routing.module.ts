import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameComponent } from './game/game.component';
import { LoginComponent } from './login/login.component';
import { WinnerComponent } from './winner/winner.component';

const routes: Routes = [
  { path: 'game', component: GameComponent },
  { path: '', redirectTo: '/start', pathMatch: 'full' },
  { path: 'start', component: LoginComponent },
  { path: 'winner', component: WinnerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
