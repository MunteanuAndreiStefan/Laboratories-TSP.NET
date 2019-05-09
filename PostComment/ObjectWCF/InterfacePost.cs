using PostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace ObjectWCF
{
    [ServiceContract]
    interface InterfacePost
    {
        [OperationContract]
        bool AddPost(Post post);
        [OperationContract]
        Post UpdatePost(Post post);
        [OperationContract]
        int DeletePost(int id);
        [OperationContract]
        Post GetPostById(int id);
        [OperationContract]
        List<Post> GetPosts();
    }
}
