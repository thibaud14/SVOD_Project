class Video < ActiveRecord::Base
  attr_accessible :bo_url, :country, :duration, :position, :season, :synopsis, :tagline, :thumbnail_url, :title, :type, :video_url, :year, :star_rating_avg
  has_and_belongs_to_many :peoples
  has_and_belongs_to_many :user
  has_and_belongs_to_many :genres
  has_and_belongs_to_many :subtitles
  has_and_belongs_to_many :langues
  belongs_to :collection
  has_many :reviews


end
