using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public class AVLElement : TreeElement
    {
        public int height;
        //public new AVLElement right;
        //public new AVLElement left;

        public AVLElement(int c) : base(c)
        {
        }

        public int HeightCalc()
        {
            if(left != null && right != null)
            {
                if (((AVLElement)left).HeightCalc() < ((AVLElement)right).HeightCalc())
                    height = ((AVLElement)right).HeightCalc() + 1;

                else if (((AVLElement)left).HeightCalc() > ((AVLElement)right).HeightCalc() || ((AVLElement)left).HeightCalc() == ((AVLElement)right).HeightCalc())
                    height = ((AVLElement)left).HeightCalc() + 1;
            }

            else if (left == null && right == null) // leaf
                height = 1;

            else if (left == null)
                height = ((AVLElement)right).HeightCalc() + 1;


            else if (right == null)
                height = ((AVLElement)left).HeightCalc() + 1;


            return height;
        }

        public int BalanceFactor()
        {

            int heightR = 0;
            int heightL = 0;
            if ((AVLElement)right == null && (AVLElement)left == null)
            {
                int fu = 69;
                int ck = 420;
            }

            else if ((AVLElement)right == null)
            {
                heightL = ((AVLElement)left).height; 
            }

            else if ((AVLElement)left == null)
            {
                heightR = ((AVLElement)right).height;
            }

            else
            {
                heightR = ((AVLElement)right).height;
                heightL = ((AVLElement)left).height;
            }


            return heightR - heightL;
        }

        public void RightRotation()
        {
            AVLElement temp;
            int temp2 = left.content;

            left.content = content;
            content = temp2;

            temp = (AVLElement)left;
            left = (AVLElement)right;
            right = temp;

            temp = (AVLElement)left;
            left = right.left;
            right.left = temp;

            temp = (AVLElement)right.right;
            right.right = right.left;
            right.left = temp;
        }

        public void LeftRotation()
        {
            AVLElement temp;
            int temp2 = right.content;

            right.content = content;
            content = temp2;

            temp = (AVLElement)right;
            right = (AVLElement)left;
            left = temp;

            temp = (AVLElement)right;
            right = left.right;
            left.right = temp;

            temp = (AVLElement)left.left;
            left.left = left.right;
            left.right = temp;
        }

        public AVLElement BFSearch()
        {
            AVLElement l, r;

            if (right != null || left != null)
            {
                int BF = 0;
                int BFR = 0;
                int BFL = 0;

                if(right == null)
                {
                    BF = System.Math.Abs(BalanceFactor());
                    BFL = System.Math.Abs(((AVLElement)left).BalanceFactor());
                }
                else if (left == null)
                {
                    BF = System.Math.Abs(BalanceFactor());
                    BFR = System.Math.Abs(((AVLElement)right).BalanceFactor());
                }
                else
                {
                    BF = System.Math.Abs(BalanceFactor());
                    BFR = System.Math.Abs(((AVLElement)right).BalanceFactor());
                    BFL = System.Math.Abs(((AVLElement)left).BalanceFactor());
                }

                if (BF == 2)
                {
                    if (BFL == 1 || BFR == 1)
                    {
                        return this;
                    }
                    else
                    {
                        l = ((AVLElement)left).BFSearch();
                        r = ((AVLElement)right).BFSearch();

                        return l ?? r; // TODO: if kaputt this is probablz schuld
                    }
                }
                else
                {
                    l = null;
                    r = null;

                    if (left != null)
                        l = ((AVLElement)left).BFSearch();

                    if (right != null)
                        r = ((AVLElement)right).BFSearch();

                    return l ?? r; // TODO: if kaputt this is probablz schuld
                }
            }

            return null;
        } 
    }
}
