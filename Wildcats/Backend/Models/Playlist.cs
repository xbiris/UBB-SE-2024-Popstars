namespace ISS_Wildcats.Backend.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class Playlist
{
	public int PlaylistID { get; set; }
	public string Name { get; set; }
	public List<int> SongIDs { get; set; } = new List<int>();
	public int CreatorID { get; set; }
}