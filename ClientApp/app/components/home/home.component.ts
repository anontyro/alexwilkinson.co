import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    public latestPost: JSON;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        http.get(originUrl + '/api/BlogPosts/latest').subscribe(response => {
            this.latestPost = response.json();
        });
    }

}

interface BlogPost {

}

