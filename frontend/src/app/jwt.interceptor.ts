import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { take } from "rxjs";
import { UserDto } from "./Dto/login.dto";
import { UserService } from "./users/user.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private userService: UserService){}

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        this.userService.currentUser$.pipe(take(1)).subscribe(
            (user: UserDto | null) => {
                if(user){
                    req = req.clone({
                        setHeaders: {
                            Authorization: `Bearer ${user.token}`
                        }
                    })
                }
            }
        )
        return next.handle(req);
    }
    
}