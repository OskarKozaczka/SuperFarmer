import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AnimalsComponent } from './animals/animals.component';
import { LoginComponent } from './login/login.component';
import { GameComponent } from './game/game.component';
import { DiceComponent } from './dice/dice.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TradeComponent } from './trade/trade.component';
import { WinnerComponent } from './winner/winner.component';
import { BankComponent } from './bank/bank.component';

@NgModule({
  declarations: [
    AppComponent,
    AnimalsComponent,
    LoginComponent,
    GameComponent,
    DiceComponent,
    TradeComponent,
    WinnerComponent,
    BankComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
