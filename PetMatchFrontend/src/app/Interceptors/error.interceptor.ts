import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import Swal from 'sweetalert2';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private router: Router) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error.status === 401) {
                    if(error.error && error.error.title === 'Invalid credentials.'){
                        Swal.fire({
                            icon: 'error',
                            title: 'LOGIN FAILED.',
                            text: 'USERNAME OR PASSWORD ARE INCORRECT.',
                          });
                    }else{
                        this.router.navigate(['/login']);
                    }
                }

                return throwError(error);
            })
        );
    }
}
