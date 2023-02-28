import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NavigationExtras, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable } from 'rxjs/internal/Observable';
import { catchError, tap } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router, private toastrService: ToastrService) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
            return next.handle(req).pipe(
                    catchError((error: HttpErrorResponse) => {
                        if(error){
                            switch(error.status){
                                case 400:
                                    const errors = error.error.errors;
                                    if(errors){
                                        const modelStateErrors = [];
                                        for(const key in errors){
                                            if(errors[key]){
                                                modelStateErrors.push(errors[key])
                                            }
                                        }
                                        throw modelStateErrors.flat();
                                    }else{
                                        this.toastrService.error(error.error, error.status.toString());
                                        
                                    }
                                    break;
        
                                case 401:{
                                    this.toastrService.error('Unauthorised', error.status.toString());
                                    localStorage.removeItem('user');
                                    this.router.navigateByUrl('/login');
                                    break;
                                }
                                case 404:
                                    this.router.navigateByUrl('/not-found')
                                    break;
                                case 500:
                                    const jsonObject = JSON.parse(error.error);
                                    const userMessage = jsonObject.message;
                                    console.log(userMessage)

                                    let message = userMessage ? userMessage : 'Server error! Please contact with support.';
                                    this.toastrService.error(message);
                                    break;
                                default:
                                    this.toastrService.error('Something unexpected went wrong!. Please contact with support.');
                                    console.log(error);
                            }
                        }
                        throw error
                    })
                )
        }
    }