#region LGPL License
/*----------------------------------------------------------------------------
* This file (Yodii.Script\Analyser\Expressions\SyntaxErrorExpr.cs) is part of CiviKey. 
*  
* CiviKey is free software: you can redistribute it and/or modify 
* it under the terms of the GNU Lesser General Public License as published 
* by the Free Software Foundation, either version 3 of the License, or 
* (at your option) any later version. 
*  
* CiviKey is distributed in the hope that it will be useful, 
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the 
* GNU Lesser General Public License for more details. 
* You should have received a copy of the GNU Lesser General Public License 
* along with CiviKey.  If not, see <http://www.gnu.org/licenses/>. 
*  
* Copyright © 2007-2015, 
*     Invenietis <http://www.invenietis.com>,
* All rights reserved. 
*-----------------------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yodii.Script
{
    public class SyntaxErrorExpr : Expr
    {
        public static readonly SyntaxErrorExpr ReservedErrorExpr = new SyntaxErrorExpr( SourceLocation.Empty, "Reserved." );

        public SyntaxErrorExpr( SourceLocation location, string errorMessageFormat, params object[] messageParameters )
            : base( location )
        {
            ErrorMessage = String.Format( errorMessageFormat, messageParameters );
        }

        public string ErrorMessage { get; private set; }

        public bool IsReserved
        {
            get { return this == ReservedErrorExpr; }
        }

        [DebuggerStepThrough]
        internal protected override T Accept<T>( IExprVisitor<T> visitor )
        {
            return visitor.Visit( this );
        }

        public override string ToString()
        {
            return "Syntax: " + ErrorMessage;
        }
    }

}