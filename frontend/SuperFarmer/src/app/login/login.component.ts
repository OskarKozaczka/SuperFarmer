import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { ApiService } from '../api.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router,private api: ApiService, private http: HttpClient) { }

  ngOnInit(): void {
  }

  onSubmit(gameID: string, playerName: string) {
    this.api.gameID = gameID;
    this.api.playerName = playerName;

    var url = this.api.URL+"newGame/"+this.api.gameID+"/"+this.api.playerName;
    this.http.post(url,null).subscribe({
      next: (v) => {this.router.navigate(['/game']);},
      complete: () => {
        console.info('complete'); 
      }
    }
    );
  }

}
