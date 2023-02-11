import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environment/environment";
import { AuthService } from "./auth.service";

const baseUrl = `${environment.apiUrl}/pets`

@Injectable({
  providedIn: "root"
})
export class PetService {
    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      });
  constructor(private http: HttpClient, private authService: AuthService) {}

getAll() {
    return this.http.get(baseUrl, { headers: this.headers});
}

getById(id: string) {
    return this.http.get(`${baseUrl}/${id}`, { headers: this.headers});
}

create(params: any) {
    return this.http.post(baseUrl, params, { headers: this.headers});
}

update(id: string, params: any) {
    return this.http.put(`${baseUrl}/${id}`, params, { headers: this.headers});
}

delete(id: string) {
    return this.http.delete(`${baseUrl}/${id}`, { headers: this.headers});
}
}