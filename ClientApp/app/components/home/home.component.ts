import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { BlogPost } from '../blogview/bloglist/blogpost/blogpostmodel';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    private blogList: BlogPost[] =[];
    public latestPost: JSON;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        http.get(originUrl + '/api/BlogPosts/latest').subscribe(response => {
            this.latestPost = response.json();
        });

        http.get(originUrl + '/api/BlogPosts/range/')
            .map(response => response.json() as BlogPost[])
            .subscribe(response => {
                this.blogList = response;
                console.log(this.blogList);
            });

    }

}


