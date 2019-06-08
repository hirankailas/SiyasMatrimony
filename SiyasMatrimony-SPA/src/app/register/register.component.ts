import { Component, OnInit, ViewChild, ElementRef, ViewContainerRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Religion } from '../_models/Religion';
import { HelperService } from '../_services/helper.service';
import { map, count } from 'rxjs/operators';
import { User } from '../_models/User';
import { AlertifyService } from '../_services/alertify.service';
import { Caste } from '../_models/Caste';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { Helper } from '../_models/Helper';
import { Star } from '../_models/Star';
import { Rashi } from '../_models/Rshi';
import { Country } from 'ngx-international-phone-number';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistermodalComponent } from './register_modal/register_modal.component';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @ViewChild('firstName') firstNameElement: ElementRef;
  @ViewChild('registerForm') registerForm: NgForm;
  user: Partial<User>;
  religions: Religion[];
  castes: Caste[];
  countries: Country[];
  states = [];
  cities = [];
  genderOptions: any[] = ['Select Gender', 'Male', 'Female'];
  mariatalStatus: any[] = ['Select Marital Status', 'Never Married', 'Widower', 'Divorced', 'Awaiting Divorce'];
  profileFors: any[] = ['Profile Created For', 'MySelf', 'Son', 'Daughter', 'Brother', 'Sister' , 'Relative' , 'Friend'];
  mothertongues: any[] = ['Malayalam', 'Tamil', 'Kannada', 'English' , 'Hindi'];
  doshams = ['Yes', 'No', 'Dont Know'];
  familystatuses = ['Middle Class', 'Upper Middle Class', 'Rich', 'Affluent'];
  familytypes = ['Joint Family','Nuclear Family', 'Others'];
  familyvalues = ['Orthodox', 'Traditional', 'Moderate', 'Liberal'];
  stars: Star[];
  rashis: Rashi[];
  bsConfig: Partial<BsDatepickerConfig>;
  helper: Helper;
  constructor(public helperService: HelperService, private alertify: AlertifyService, private modalService: NgbModal) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red'
     };
     this.helper = new Helper();
    this.fillRelegions();
    this.fillStars();
    this.fillAllCountries();
    this.user = {profileCreatedFor: 'Profile Created For', gender: 'Select Gender', maritalStatus: 'Select Marital Status'};
    //this.firstNameElement.nativeElement.focus();
  }

  // events
  onProfileCreatedChanged(event) {
    console.log(this.user.profileCreatedFor);
    console.log(event.currentTarget.value);
  }
  onMaritalChanged(event){
    this.user.maritalStatus = event.currentTarget.value;
  }

  onRelegionChanged(event){
    let selectedValue: string;
    selectedValue = event.value.id;
    this.castes = this.religions.find( p => p.id === Number(selectedValue)).castes;
  }
  onDoshamChanged(event) {
    this.user.chovvaDosam = event.currentTarget.value;
  }
  onFamilyStatusChanged(event){
    this.user.familyStatus = event.value;
  }
  onFamilyTypeChanged(event) {
    this.user.familyType = event.value;
  }
  onFamilyValueChanged(event) {
    this.user.familyValues = event.value;
  }
  onCountryChanged(event) {
    this.user.country = event.value.id;
    this.states = event.value.states;
  }
  onStateChanged(event) {
    this.user.state = event.value.id;
    this.helperService.GetAllCities(event.value.id).subscribe((cities: any) => {
      this.cities = cities;
    },error =>{
      this.alertify.error(error);
    });
  }
  onCityChanged(event) {
    this.user.city = event.value.id;
  }
  onCasteChanged(event) {
    this.user.cast = event.value.name;
  }
  onStarChanged(event) {
    const selectedValue: number = event.value.id;
    this.rashis = this.stars.find( p => p.id === Number(selectedValue)).rashi;
  }

  // Methods
  fillRelegions()  {
    this.helperService.GetAllRelegions().subscribe((religions: Religion[] ) => {
     this.religions = religions;
    }, error => {
      this.alertify.error(error);
    }
    );
  }

  fillAllCountries(){
    this.helperService.GetAllCountries().subscribe((countries: any) =>{
      this.countries = countries;
    }, error =>{
      this.alertify.error(error);
    });
  }

  fillStars() {
    this.helperService.GetAllStars().subscribe((stars: Star[]) => {
      this.stars = stars;
    });
  }

  Register(){
   // console.log(JSON.stringify(this.user.name));
    const modalRef = this.modalService.open(RegistermodalComponent);
    modalRef.componentInstance.user = this.user;
    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }

  IsValidProfile(){
    return this.user.profileCreatedFor === 'Profile Created For';
  }

  IsValidGender(){
    return this.user.gender === 'Select Gender';
  }
  IsValidMstatus(){
    return this.user.maritalStatus === 'Select Marital Status';
  }
  IsValidMobileNUmber(){
    return this.user.mobileNumber === 'Select Marital Status';
  }
}
