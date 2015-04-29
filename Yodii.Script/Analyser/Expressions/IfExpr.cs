#region LGPL License
/*----------------------------------------------------------------------------
* This file (Yodii.Script\Analyser\Expressions\IfExpr.cs) is part of CiviKey. 
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
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CK.Core;
using System.Diagnostics;

namespace Yodii.Script
{

    public class IfExpr : Expr
    {
        public IfExpr( SourceLocation location, bool isTernary, Expr condition, Expr whenTrue, Expr whenFalse )
            : base( location, true )
        {
            IsTernaryOperator = isTernary;
            Condition = condition;
            WhenTrue = whenTrue;
            WhenFalse = whenFalse;
        }

        /// <summary>
        /// Gets whether this is a ternary ?: expression (<see cref="WhenFalse"/> necessarily exists). 
        /// Otherwise, it is an if statement: <see cref="WhenTrue"/> and WhenFalse are
        /// Blocks (and WhenFalse may be null).
        /// </summary>
        public bool IsTernaryOperator { get; private set; }

        public Expr Condition { get; private set; }

        public Expr WhenTrue { get; private set; }

        public Expr WhenFalse { get; private set; }

        [DebuggerStepThrough]
        internal protected override T Accept<T>( IExprVisitor<T> visitor )
        {
            return visitor.Visit( this );
        }

        public override string ToString()
        {
            string s = "if(" + Condition.ToString() + ") then {" + WhenTrue.ToString() + "}";
            if( WhenFalse != null ) s += " else {" + WhenFalse.ToString() + "}";
            return s;
        }
    }


}