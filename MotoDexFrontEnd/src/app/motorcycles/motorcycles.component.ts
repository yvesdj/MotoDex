import { Component, OnInit } from '@angular/core';
import { IMotorcycle, MotorcyclesService } from '../services/motorcycles.service';


@Component({
  selector: 'app-motorcycles',
  templateUrl: './motorcycles.component.html',
  styleUrls: ['./motorcycles.component.css']
})
export class MotorcyclesComponent implements OnInit {

  get motorcycleModel(): IMotorcycle{
    
    console.log(this._motoService.selectedMotorcycle)
    return this._motoService.selectedMotorcycle
  }

  // selectedMoto: any;

  

  constructor(private _motoService: MotorcyclesService) {
    
  }

  ngOnInit(): void {
  }

  // ngOnDestroy() {
  //   //prevent memory leak when component destroyed
  //    this._subscription.unsubscribe();
  //  }

  // async GetData(){
  //   this.motorcycles = await this._motoService.GetMotorcycles;
  // }

}
