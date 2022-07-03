import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiService, rollReponse } from '../api.service';
import { Router, RouterModule } from '@angular/router'
import { AnimalsComponent } from '../animals/animals.component';

@Component({
  selector: 'app-dice',
  templateUrl: './dice.component.html',
  styleUrls: ['./dice.component.css']
})
export class DiceComponent implements OnInit {

  firstRoll :String = ''
  secondRoll :String = ''
  AnimalArray: Array<String> = ["rabbit","sheep","pig","cow","horse","wolf","fox"]

  constructor(private http: HttpClient, public api: ApiService, private router:RouterModule) { }

  ngOnInit(): void {
  }

  Roll()
  {
    var url = this.api.URL+"Roll/"+this.api.gameID+"/"+this.api.playerName;
    this.http.post<rollReponse>(url, null).subscribe({
      next: (v) => {
        console.log(v)
        this.api.trade = true
        this.firstRoll = this.AnimalArray[v.rollResult[0]];
        this.secondRoll = this.AnimalArray[v.rollResult[1]];
        this.api.UpdateAnimals(v.animals)
        this.api.currentPlayer = v.nextPlayer;
      },
      complete: () => console.info('complete') 
    }
    );
  }
}
