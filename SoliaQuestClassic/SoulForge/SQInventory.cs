using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public class SQInventory
    {
        private string inventoryOwner = "";
        private string inventoryName = "";
        private int inventorySize = 1;

        private SQItemStack[] contents;
        public SQItemStack[] Contents { get { return contents; } set { contents = value; } }

        public SQInventory(int size)
        {
            inventorySize = size;
            contents = new SQItemStack[size];
            for(int i = 0; i < size; i++)
            {
                contents[i] = new SQItemStack();
            }
        }

        public int AddItemStack(SQItemStack stack, out SQItemStack overflow)
        {
            SQItemStack stackRemains = stack.Grab();
            int start = 0;
            while (!stackRemains.IsEmptyStack)
            {
                for (int i = start; i < contents.Length; i++)
                {
                    if (contents[i].StackItem.IsEqual(stackRemains.StackItem))
                    {
                        SQItemStack extras;
                        contents[i].Combine(stackRemains, out extras);
                        if (extras.IsEmptyStack)
                        {
                            overflow = new SQItemStack();
                            return 1;
                        }
                        else
                        {
                            stackRemains = extras.Grab();
                        }
                    }
                    else if (contents[i].IsEmptyStack)
                    {
                        if (!stackRemains.IsFloatingStack)
                        {
                            contents[i].Replace(stackRemains);
                            overflow = SQItemStack.Empty;
                            return 1; //empty spot found for item.
                        }
                        else
                        {
                            SQItemStack extras;
                            stackRemains.Sink(out extras);
                            contents[i].Replace(stackRemains);
                            stackRemains = extras;
                        }
                    }
                }
                if (start == inventorySize) { break; }
            }
            if (stackRemains.IsEmptyStack)
            {
                overflow = SQItemStack.Empty;
                return 1;
            }
            else
            {
                overflow = stackRemains;
                return 0; //inventory is full.
            }
        }
        public SQItemStack TakeItemStack(int position)
        {
            if(position >= 0 && position < contents.Length)
            {
                return contents[position].Grab();
            }
            else { return new SQItemStack(); }
        }
        public int PlaceItemStack(SQItemStack stackHeld, int position, out SQItemStack overflow)
        {
            SQItemStack stack = stackHeld.Grab();
            if(position >= 0 && position < contents.Length && !stack.IsEmptyStack)
            {
                SQItemStack extras;
                if (stack.StackItem.IsEqual(contents[position].StackItem))
                {
                    contents[position].Combine(stack, out extras);
                    if (extras.IsEmptyStack)
                    {
                        overflow = new SQItemStack();

                        return 1;
                    }
                    else
                    { overflow = extras.Grab(); return 2; }
                }
                else if(contents[position].IsEmptyStack)
                {
                    contents[position].Replace(stack);
                    if (stack.StackSize > stack.StackMaxSize)
                    {
                        overflow = new SQItemStack(stack.StackItem, stack.StackSize - stack.StackMaxSize, out _, true);
                        return 1;
                    }
                    overflow = new SQItemStack();
                    return 1;
                }
                else
                { overflow = stack.Grab(); return 2; }
            }
            else { overflow = stack.Grab(); return -1; }
        }
    }
}
