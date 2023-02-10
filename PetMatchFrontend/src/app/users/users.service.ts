import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class UsersService {
  constructor(private http: HttpClient) {}

  login(user: any): Observable<any> {
    return this.http.post("http://localhost:4000/authentication/login", user);
  }
  register(user: any): Observable<any> {
    return this.http.post("http://localhost:4000/authentication/register", user);
  }
}