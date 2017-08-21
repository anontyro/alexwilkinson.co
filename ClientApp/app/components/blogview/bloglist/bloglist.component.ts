import { Component, Inject, OnInit } from '@angular/core';
import { BlogPost } from './blogpost/blogpostmodel';

@Component({
    selector: 'blog-list',
    templateUrl: './bloglist.component.html',
    styleUrls: ['./bloglist.component.css']
})

export class BlogListComponent implements OnInit {

    @Inject('ORIGIN_URL') originUrl: string


    constructor() {}



    ngOnInit(): void {}

}