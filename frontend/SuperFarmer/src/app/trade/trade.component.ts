import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Animals, ApiService } from '../api.service';

@Component({
  selector: 'app-trade',
  templateUrl: './trade.component.html',
  styleUrls: ['./trade.component.css']
})
export class TradeComponent implements OnInit {

  constructor(public api : ApiService,private http: HttpClient) { }

  ngOnInit(): void {
  }

  trade (tradeID: number)
  {
    var url = this.api.URL+"Trade/"+this.api.gameID+"/"+this.api.playerName+"/"+tradeID;
    this.http.post<Animals>(url, null).subscribe({
      next: (v) => {
        this.api.trade = false
        this.api.UpdateAnimals(v)
      },
      complete: () => console.info('complete') 
    }
    );
  }
}
