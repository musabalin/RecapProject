using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            
            return new List<OperationClaim>( _userDal.GetClaims(user));

        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new Result(ResultStatus.Success);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new DataResult<List<User>>(ResultStatus.Success,_userDal.GetAll());
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
