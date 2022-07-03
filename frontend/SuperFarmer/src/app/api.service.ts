import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { interval } from 'rxjs';


export interface Animals {
  rabbits: number;
  sheeps: number;
  pigs: number;
  cows: number;
  horses: number;
  smallDogs: number;
  largeDogs: number;
}

export interface rollReponse{
  rollResult : Array<number>;
  nextPlayer : string;
  animals : Animals;

}


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  public gameID: String = "";
  public playerName: String = "";
  public currentPlayer : String = "";
  public trade: Boolean = true;

  rabbits :number = 0;
  sheeps :number = 0;
  pigs :number = 0;
  cows :number = 0;
  horses :number = 0;
  smallDogs :number = 0;
  largeDogs :number = 0;

  bankrabbits :number = 60;
  banksheeps :number = 24;
  bankpigs :number = 20;
  bankcows :number = 12;
  bankhorses :number = 6;
  banksmallDogs :number = 4;
  banklargeDogs :number = 2;


  public URL: string = "https://localhost:4300/api/"
  

  constructor(private http: HttpClient, private router:Router) {
    interval(1000).subscribe(() => {
    this.UpdateCurrentPlayer();
  }); }

  UpdateAnimals(animals: Animals){
        this.rabbits = animals.rabbits
        this.sheeps = animals.sheeps
        this.pigs = animals.pigs
        this.cows = animals.cows
        this.horses = animals.horses
        this.smallDogs = animals.smallDogs
        this.largeDogs = animals.largeDogs
        this.CheckWin()
        this.UpdateBank()
  }


  CheckWin(){
    if (this.rabbits == 0) return false;
    if (this.sheeps == 0) return false;
    if (this.pigs == 0) return false;
    if (this.cows == 0) return false;
    if (this.horses == 0) return false;

    this.router.navigate(['/winner']);
    return true;
  }

  UpdateBank(){
    var url = this.URL+"GetBank/"+this.gameID;
    this.http.get<Animals>(url).subscribe({
      next: (animals) => {        
        this.bankrabbits = animals.rabbits
        this.banksheeps = animals.sheeps
        this.bankpigs = animals.pigs
        this.bankcows = animals.cows
        this.bankhorses = animals.horses
        this.banksmallDogs = animals.smallDogs
        this.banklargeDogs = animals.largeDogs
      },
      complete: () => console.info('complete') 
    }
    );
  }

  UpdateCurrentPlayer(){
    if (this.playerName == '') return
    var url = this.URL + "GetCurrentPlayer/"+this.gameID;
    this.http.get<string>(url).subscribe({
      next: (x) => {       
        this.currentPlayer = x;
      },
      complete: () => console.info('complete') 
    }
    );
  }
}
