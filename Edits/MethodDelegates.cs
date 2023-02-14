using System;
namespace NHAssist.Edits
{
    internal delegate bool PreDrawOrigin(ModProjectile modProjectile, ref Color lightColor);
    internal delegate bool PreDrawDelegate(PreDrawOrigin origin, ModProjectile modProjectile, ref Color lightColor);
}

