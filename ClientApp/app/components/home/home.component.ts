import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { RouterModule, Router, NavigationEnd } from '@angular/router';
import 'rxjs/add/operator/map';
import { BlogPost } from '../blogview/bloglist/blogpost/blogpostmodel';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    public latestPost: JSON;

    constructor(
        private http: Http,
        @Inject('ORIGIN_URL') originUrl: string,
        private router: Router,
    ) {
        http.get(originUrl + '/api/BlogPosts/latest').subscribe(response => {
            this.latestPost = response.json();

            this.router.events.subscribe(e => {
                if (e.constructor.name === "NavigationStart")
                {
                    console.log(e);
                }
                
            });
        });


    }

}



