﻿//$ Copyright 2016, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//

using UnityEngine;
using System.Collections;
using DungeonArchitect;

namespace DungeonArchitect
{
    /// <summary>
    /// Meta-data added to each spawned game object in the scene.  This is used to identify objects that belong to the dungeons, for later destruction and rebuilding
    /// </summary>
    public class DungeonSceneProviderData : MonoBehaviour
    {
		/// <summary>
		/// The graph node id this game object was spawned from in the theme graph
		/// </summary>
        public string NodeId;

		/// <summary>
		/// The dungeon this game object belongs to
		/// </summary>
        public Dungeon dungeon;

		/// <summary>
		/// Indicates if the geometry in this node contributes to navigation mesh generation
		/// This flag reflects the state set in the theme graph's visual node affectsNavigation flag
		/// </summary>
		public bool affectsNavigation = false;
    }
}
