import { Component, OnInit,Input } from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import { HelperService } from 'src/app/_services/helper.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-register_modal',
  templateUrl: './register_modal.component.html',
  styleUrls: ['./register_modal.component.css']
})

export class RegistermodalComponent implements OnInit {
@Input() public user;
constructor(public activeModal: NgbActiveModal, private helperService: HelperService,
            private alertify: AlertifyService, private authService: AuthService ) {
    }

  ngOnInit() {
    //console.log(this.user);
  }
  closeModal() {
    this.activeModal.close('Modal Closed');
  }

  RegisterUser() {
    this.helperService.PasswordGenerator().subscribe(password=>{
      this.user.password = password;
    }, err =>{
      this.alertify.error(err);
    });

    this.authService.Register(this.user).subscribe(result =>{
      this.alertify.success('Regisred Successfully!!!');
      this.closeModal();
    }, error => {
      for (const err of error.error) {
        this.alertify.error(err.description);
      }
    });
  }

}
