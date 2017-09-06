import { Component } from '@angular/core';
import { BlogPost } from './bloglist/blogpost/blogpostmodel';
import { BlogListService } from '../../services/index';

@Component({
    selector: 'blog-view',
    templateUrl: './blogview.component.html',
    styleUrls: ['./blogview.component.css']
})

export class BlogviewComponent{
    private blogList: Object;
    constructor(
        private blogListService: BlogListService,
    ) {
        this.blogListService.getList().subscribe(response => {
            this.blogList = response;
            console.log(this.blogList);
        });
    }

}