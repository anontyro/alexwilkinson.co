import { Component, Inject, OnInit, Input } from '@angular/core';
import { BlogPost } from './blogpost/blogpostmodel';

@Component({
    selector: 'blog-list',
    templateUrl: './bloglist.component.html',
    styleUrls: ['./bloglist.component.css']
})

export class BlogListComponent implements OnInit {


    @Input()
    blogList: BlogPost[];

    constructor(
        @Inject('ORIGIN_URL') originUrl: string,
    ) { }



    ngOnInit(): void {}

}