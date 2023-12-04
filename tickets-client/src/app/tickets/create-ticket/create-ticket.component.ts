import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ticket } from 'src/app/models/ticket';
import { TicketsService } from '../tickets.service';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.scss']
})
export class CreateTicketComponent {

  ticket: Ticket={governorate:'Cairo',city:'Shoubra',district:'First'};
  errors: string[]  = [];
  isDone=false;
  ticketForm!:FormGroup;
  constructor(private fb: FormBuilder,private ticketService:TicketsService) { }

  ngOnInit() {
    this.isDone=false;
    this.ticketForm = this.fb.group({
      phoneNumber: ['', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{11}$")]],
      governorate: ['', Validators.required],
      city: ['', Validators.required],
      district: ['', Validators.required]
    });



  }



  onSubmit(){
    this.errors=[]
    if(this.ticketForm?.controls['phoneNumber'].errors){
      if(this.ticketForm?.controls['phoneNumber'].errors['required']){
        this.errors?.push("Phone number is required");
  }
       if(this.ticketForm?.controls['phoneNumber'].errors['pattern']){
             this.errors?.push("Phone number should has 11 numeric values");
       }
      return;
    }
  
    this.ticket.creationDate = new Date();
    console.log(this.ticket)
    this.ticketService.create(this.ticket).subscribe({
      next: () => {
         this.isDone=true;
        this.ticket={}}
    })


    console.log(this.ticketForm.value)
     
    console.log(this.errors)
  }


  Governates = [
    { id: 1, name: "Cairo" },
    { id: 2, name: "Qalubyia" },
    { id: 3, name: "Qena" },
    { id: 4, name: "Aswan" },
    { id: 5, name: "Giza" }
  ];

  Cities = [
    { id: 1, name: "Shoubra" },
    { id: 2, name: "Haram" },
    { id: 3, name: "Tagamoa" }
  ];


  Distinct = [
    { id: 1, name: "First" },
    { id: 2, name: "Second" },
    { id: 3, name: "Fifth" }
  ];

}
