﻿namespace Problem1117
{
    public class H2O
    {
        private int oCount = 0;
        private int hCount = 0;
        public H2O()
        {

        }

        public void Hydrogen(Action releaseHydrogen)
        {

            // releaseHydrogen() outputs "H". Do not change or remove this line.
            releaseHydrogen();
        }

        public void Oxygen(Action releaseOxygen)
        {
           
            // releaseOxygen() outputs "O". Do not change or remove this line.
            releaseOxygen();
        }
    }
}