using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UR_Talking.DAO
{
    public interface AnswerDAO
    {
       string GetAnswer(List<SearchObject> searchObjects);
    }
}
