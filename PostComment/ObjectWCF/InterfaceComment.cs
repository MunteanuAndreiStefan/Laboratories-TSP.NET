using PostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ObjectWCF
{
    [ServiceContract]
    interface InterfaceComment
    {
        [OperationContract]
        bool AddComment(Comment comment);
        [OperationContract]
        Comment UpdateComment(Comment newComment);
        [OperationContract]
        Comment GetCommentById(int id);
    }
}
