using System;
using System.Collections.Generic;
using System.Text;

namespace EcobanPro.Services
{
    public interface IGoogleAuthService
    {
        void Autheticate(IGoogleAuthenticationDelegate googleAuthenticationDelegate);

    }
}
