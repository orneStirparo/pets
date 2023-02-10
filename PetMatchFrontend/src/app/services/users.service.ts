import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../environment/environment"


@Injectable({
  providedIn: "root"
})
export class UsersService {
  constructor(private http: HttpClient) {}

  login(user: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}/authentication/login`, user);
  }
  register(user: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}/authentication/register`, user);
  }
}