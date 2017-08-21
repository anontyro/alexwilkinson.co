"use strict";
export class BlogPost {

    constructor(
        public id: number,
        private authorId: number,
        public body: string,
        public coverImg: string,
        public date: string,
        private draft: number,
        public lastModified: string,
        private publish: string,
        public slug: string,
        public title: string,
    ) {
    }

}