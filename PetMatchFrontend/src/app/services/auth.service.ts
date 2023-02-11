import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string | null;

  constructor() {
    this.token = localStorage.getItem('token');
  }

  getToken() {
    return this.token;
  }
}