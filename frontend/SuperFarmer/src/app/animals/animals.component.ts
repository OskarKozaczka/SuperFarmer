import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Animals, ApiService } from '../api.service';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html',
  styleUrls: ['./animals.component.css']
})
export class AnimalsComponent implements OnInit {
  constructor(public api: ApiService, private http: HttpClient) { }


  ngOnInit(): void {
    this.UpdateAnimalsOnInit()
  }


  UpdateAnimalsOnInit(){
    var url = this.api.URL+"GetAnimals/"+this.api.gameID+"/"+ this.api.playerName;

    this.http.get<Animals>(url).subscribe({
      next: (animals) => {  
        this.api.UpdateAnimals(animals)      
      },
      complete: () => console.info('complete') 
    }
    );
  }
}
