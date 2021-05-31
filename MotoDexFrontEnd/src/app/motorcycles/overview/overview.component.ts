import { Component, OnInit } from '@angular/core';
import { IMotorcycle, MotorcyclesService } from 'src/app/services/motorcycles.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {
  typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
  motorcycles: IMotorcycle[] = [];

  selectedMoto: any;


  constructor(private _motoService: MotorcyclesService) { }

  ngOnInit(): void {
    this.GetData();
  }

  async GetData(){
    try {
      this.motorcycles = await this._motoService.GetJsonMotorcycles();
    } catch (error) {
      console.log(error)
    }
  }

  onNgModelChange(event: any){
    this._motoService.selectedMotorcycle = this.selectedMoto;
  }


}
