import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MotorcyclesService } from 'src/app/services/motorcycles.service';


@Component({
  selector: 'app-add-moto',
  templateUrl: './add-moto.component.html',
  styleUrls: ['./add-moto.component.css']
})
export class AddMotoComponent implements OnInit {

  makeForm = this._formBuilder.group({
    name: '',
    summary: ''
  })

  engineForm = this._formBuilder.group({
    engineType: '',
    engineConfiguration: '',
    capacity: '',
    maxPower: '',
    maxTorque: '',
    cooling: '',
    inductionType: '',
    sparkPlug: ''
  })

  constructor(private _motoService: MotorcyclesService, private _formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  makeOnSubmit(): void {
    let body = JSON.stringify(this.makeForm.value);

    this._motoService.PostObject(body, "motorcyclemakes")
    this.makeForm.reset();
  }

  engineOnSubmit(): void {
    let body = JSON.stringify(this.engineForm.value);

    this._motoService.PostObject(body, "engines")
    this.engineForm.reset();
  }

}
