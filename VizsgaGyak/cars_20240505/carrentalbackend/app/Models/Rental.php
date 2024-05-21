<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Rental extends Model
{
    use HasFactory;

    public $fillable = ['car_id','start_date','end_date'];

    protected $hidden = ['created_at','updated_at'];
}
