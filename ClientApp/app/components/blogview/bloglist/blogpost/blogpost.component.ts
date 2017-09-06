import { Component, Input } from '@angular/core';
import { BlogPost } from './blogpostmodel';

@Component({
    selector: 'blog-post',
    templateUrl: './blogpost.component.html',
    styleUrls: ['./blogpost.component.css']
})

export class BlogPostComponent{
    @Input()
    blogPost: BlogPost;

    constructor() { }
}