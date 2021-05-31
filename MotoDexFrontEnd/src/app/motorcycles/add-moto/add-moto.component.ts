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

  tyreForm = this._formBuilder.group({
    make: '',
    model: '',
    tyreWidth: '',
    heightAspect: '',
    rimSize: ''
  })

  breakPadForm = this._formBuilder.group({
    padType: '',
    make: '',
    model: ''
  })

  motoForm = this._formBuilder.group({
    makeId: '',
    model: '',
    engineId: '',
    finalDrive: '',
    motorcycleFrontTyres: [],
    motorcycleRearTyres: [],
    frontBreakPadsId: '',
    rearBreakPadsId: '',
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

  tyreOnSubmit(): void {
    let body = JSON.stringify(this.tyreForm.value);

    this._motoService.PostObject(body, "tyres")
    this.tyreForm.reset();
  }

  breakPadOnSubmit(): void {
    let body = JSON.stringify(this.breakPadForm.value);

    this._motoService.PostObject(body, "breakpads")
    this.breakPadForm.reset();
  }

  motoOnSubmit(): void {
    console.log(this.motoForm.value);
    let body = JSON.stringify(this.motoForm.value);

    this._motoService.PostObject(body, "motorcycles")
    // this.motoForm.reset();
  }

}
