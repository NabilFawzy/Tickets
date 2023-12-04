import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ticket } from '../models/ticket';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketsService {
  baseUrl = 'https://localhost:7115/api/';
  constructor(private http: HttpClient) { }
 


  create(ticket: Ticket) {
    return this.http.post<Ticket>(this.baseUrl + 'Tickets/create', ticket)
  }

  getTickets(take:number,skip:number){
    return this.http.get<Ticket[]>(this.baseUrl + 'Tickets?take='+take+'&skip='+skip)
  }
}
