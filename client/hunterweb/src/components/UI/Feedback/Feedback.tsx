import React, {FC} from 'react';

interface IPost {
    id: number,
    datetime:string,
    date:string
    title:string,
    author_name:string,
    description:string
}

interface Props {
    post:IPost
}

const Feedback:FC<Props> = ({post}) => {
    return (
        <article key={post.id} className="flex max-w-xl flex-col items-start justify-between">
            <div className="flex items-center gap-x-4 text-xs">
                <time dateTime={post.datetime} className="text-gray-500">
                    {post.date}
                </time>

            </div>
            <div className="group relative">
                <h3 className="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                    <span className="absolute inset-0" />
                    {post.title}
                </h3>
                <p className="mt-5 line-clamp-3 text-sm leading-6 text-gray-600">{post.description}</p>
            </div>
            <div className="relative mt-8 flex items-center gap-x-4">
                <div className="text-sm leading-6">
                    <p className="font-semibold text-gray-900">
                        <span className="absolute inset-0" />
                        {post.author_name}

                    </p>
                </div>
            </div>
        </article>
    );
};

export default Feedback;