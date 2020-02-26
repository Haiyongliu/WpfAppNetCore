using System;
using System.Collections.Generic;
using System.Text;
using DataGridBinding;

namespace DataGridBinding
{
    public class MembersModel
    {
        private Member mSelectedMember;
        private MemberCollection memberCollections = new MemberCollection();

        public Member SelectedMember {
            get { return mSelectedMember; }
            set { mSelectedMember = value; }
        }

        public MemberCollection Members {
            get { return memberCollections; }
        }
        
    }
}
