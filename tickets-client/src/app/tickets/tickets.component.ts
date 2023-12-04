import { Component, OnInit } from '@angular/core';
import { TicketsService } from './tickets.service';
import { Ticket } from '../models/ticket';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.scss']
})
export class TicketsComponent implements OnInit {

 
  pageNumber=1;
  pageSize=5;
  tickets: Ticket[]=[]

  ticketsHandled: string[]=[]
  constructor(private ticketService:TicketsService) { }
  ngOnInit(): void {
   this.getTickets()
  }

  getTickets(){
    this.ticketService.getTickets(this.pageSize,this.pageNumber).subscribe(res=>{
      this.tickets=res

    })
  }

  getDiffMinutes(dateTime: any){
    const currentDate: Date = new Date();
    const orignial: Date = new Date(dateTime);

    const differenceInMillis: number = currentDate.getTime() - orignial.getTime();

    const seconds: number = Math.abs(differenceInMillis / 1000);
    const minutes: number = Math.abs(seconds / 60);

    return minutes;
  }
  getRowColor(dateTime: any,id:any){

     if(this.isItemHandled(id)) return 'table-light';

     let minutes=this.getDiffMinutes(dateTime);

     if(minutes > 60) return 'table-light'
     if(minutes > 45) return 'table-danger'
     if(minutes >30) return 'table-primary'
     if(minutes > 15) return 'table-success'
     if(minutes <= 15) return 'table-warning'


     return 'table-light'
  }

  isItemHandled(id:any){
    return this.ticketsHandled.filter(x=>x == id).length>0;
  }



  onPageChanged(event :any){
    this.pageNumber =event.page;
    this.getTickets()
}

HandleNow(id:any){
  this.ticketsHandled.push(id)

}


}
